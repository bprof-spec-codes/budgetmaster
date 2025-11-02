import { Component } from '@angular/core';
import { LoginModel } from '../models/loginmodel';
import { AuthService } from '../auth.service';
import { Router } from '@angular/router';

@Component({
  selector: 'app-login',
  standalone: false,
  templateUrl: './login.component.html',
  styleUrl: './login.component.scss'
})
export class LoginComponent {

	loginModel: LoginModel = new LoginModel();
	 errorMessage: string = '';

	 constructor(public authService: AuthService, private router: Router){}

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
        // Login successful
        console.log('Login successful', response);
       this.router.navigate(['/home']); // Navigate to home 
	
      },
      error: (error) => {
        console.error('Login failed:', error);
        this.errorMessage = 'Hibás email vagy jelszó!';
      }
    });
  }
	




}

