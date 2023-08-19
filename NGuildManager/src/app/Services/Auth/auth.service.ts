import { Injectable } from '@angular/core';
import {HttpClient } from '@angular/common/http'

@Injectable({
  providedIn: 'root'
})
export class AuthService {
  private readonly apiUrl = 'https://localhost:7111/api/login';
  constructor(private http: HttpClient) { }

  loginUser(user: {email: string, password: string}) {
    return this.http.post(this.apiUrl, user);
  }
}
