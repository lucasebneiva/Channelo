import { Injectable, inject, signal, computed } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable, tap, catchError, of } from 'rxjs';
import { User, LoginCredentials, RegisterCredentials, AuthResponse } from './auth.models';

@Injectable({
  providedIn: 'root'
})
export class AuthService {
  private http = inject(HttpClient);
  private readonly baseUrl = 'http://localhost:5178/api/auth';

  // Private signal holding the current user state. null means not logged in.
  private userSignal = signal<User | null>(null);

  // Public computed signals for components to consume
  currentUser = computed(() => this.userSignal());
  isAuthenticated = computed(() => !!this.userSignal());

  constructor() {
    // If a token exists on app startup, fetch the user profile
    if (localStorage.getItem('token')) {
      this.loadMe().subscribe();
    }
  }

  register(credentials: RegisterCredentials): Observable<any> {
    return this.http.post(`${this.baseUrl}/register`, credentials);
  }

  login(credentials: LoginCredentials): Observable<AuthResponse> {
    return this.http.post<AuthResponse>(`${this.baseUrl}/login`, credentials).pipe(
      tap(response => {
        // Save the token and trigger fetching the user profile
        localStorage.setItem('token', response.token);
        this.loadMe().subscribe();
      })
    );
  }

  loadMe(): Observable<User | null> {
    return this.http.get<User>(`${this.baseUrl}/me`).pipe(
      tap(user => this.userSignal.set(user)), // Update signal with user data
      catchError(err => {
        // If the token is invalid/expired, clear the state
        this.logout();
        return of(null);
      })
    );
  }

  logout(): void {
    localStorage.removeItem('token');
    this.userSignal.set(null);
  }
}