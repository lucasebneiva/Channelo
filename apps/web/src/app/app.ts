import { Component, inject } from '@angular/core';
import { RouterOutlet } from '@angular/router';
import { AuthService } from './core/auth.service';

@Component({
  selector: 'app-root',
  imports: [RouterOutlet],
  templateUrl: './app.html',
  styleUrl: './app.scss'
})
export class App {
  // Inject the service so we can access it in the template
  public auth = inject(AuthService);

  // Temporary function to test our API
  testLogin() {
    this.auth.login({ email: 'test@test.com', password: 'Password123!' }).subscribe({
      next: () => console.log('Login successful! Check localStorage for the token.'),
      error: (err) => console.error('Login failed!', err)
    });
  }
}