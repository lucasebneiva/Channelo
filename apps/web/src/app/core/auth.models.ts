export interface User {
  id?: string;
  username: string;
  email: string;
  displayName: string;
}

export interface LoginCredentials {
  email: string;
  password?: string;
}

export interface RegisterCredentials extends LoginCredentials {
  username: string;
  displayName: string;
}

export interface AuthResponse {
  token: string;
}