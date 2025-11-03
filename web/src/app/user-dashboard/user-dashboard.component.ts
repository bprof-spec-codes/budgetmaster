import { Component, OnInit } from '@angular/core';
import { DataService } from '../data.service';
import { Observable } from 'rxjs';
import { User } from '../models/usermodel';


@Component({
	selector: 'app-user-dashboard',
	standalone: false,
	templateUrl: './user-dashboard.component.html',
	styleUrl: './user-dashboard.component.scss'
})
export class UserDashboardComponent implements OnInit {

	constructor(public dataService: DataService){}

	currentUser!: User;

	profilpictures$!: Observable<string[]>;

	readonly validCurrencies = ['HUF', 'USD', 'EUR', 'GBP'];

	ngOnInit(): void {
		this.dataService.getUser().subscribe(resp => this.currentUser = resp) 
		this.profilpictures$ = this.dataService.getAvaibleProfilPicture();
	}

	
	isFormValid(): boolean {
		return (
			this.currentUser.firstName.length > 3 &&
			this.currentUser.lastName.length > 3 &&
			this.currentUser.email.length > 5 &&
			this.currentUser.email.includes('@') &&
			this.currentUser.email.includes('.') &&
			this.currentUser.userType.length > 0 &&
			this.currentUser.currency.length > 0
		);
	}

	isValidCurrency(): boolean {
		if (this.currentUser.currency != null) {
			return this.validCurrencies.includes(this.currentUser.currency);
		}
		return false;
	}

	//TODO: HA BACKEND KÉSZ!!
	onSubmit() {
    if (this.currentUser && this.isFormValid()) {
        this.dataService.updateUser(this.currentUser).subscribe({
            next: (response) => {
                this.dataService.getUser().subscribe(user => this.currentUser = user);
                console.log('Sikeres mentés:', response);
                console.log('Sikeres mentés:', this.currentUser);
            },
            error: (err) => {
                console.error('Hiba mentés közben:', err);
            }
        });
    }
}

	
}
