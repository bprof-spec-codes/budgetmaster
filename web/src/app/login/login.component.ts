import { Component } from '@angular/core';
import { LoginModel } from '../models/loginmodel';
import { AuthService } from '../auth.service';

@Component({
  selector: 'app-login',
  standalone: false,
  templateUrl: './login.component.html',
  styleUrl: './login.component.scss'
})
export class LoginComponent {

	loginModel: LoginModel = new LoginModel();
	 errorMessage: string = '';

	 constructor(public authService: AuthService){}

	inputCheck(): boolean {
    	return !(
			this.loginModel.email.length > 5 && 
			this.loginModel.email.includes('@')&& 
			this.loginModel.email.includes('.')&& 
			this.loginModel.password.length > 3
		)
  	}

	onLogin(): void {
    this.errorMessage = '';
    
    this.authService.login(this.loginModel).subscribe({
      next: (response) => {
        // Sikeres bejelentkezés
        console.log('Login successful', response);
       // this.router.navigate(['/']);
      },
      error: (error) => {
        // Hiba kezelése
        console.error('Login failed:', error);
        this.errorMessage = 'Hibás email vagy jelszó!';
      }
    });
  }
	




}

