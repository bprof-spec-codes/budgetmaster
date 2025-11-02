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

	userModel!: User;

	profilpictures$!: Observable<string[]>;

	readonly validCurrencies = ['HUF', 'USD', 'EUR', 'GBP'];

	ngOnInit(): void {
		this.dataService.getUser().subscribe(resp => this.userModel = resp) 
		this.profilpictures$ = this.dataService.getAvaibleProfilPicture();

	}

	
	isFormValid(): boolean {
		return (
			this.userModel.firstName.length > 3 &&
			this.userModel.lastName.length > 3 &&
			this.userModel.email.length > 5 &&
			this.userModel.email.includes('@') &&
			this.userModel.email.includes('.') &&
			this.userModel.userType.length > 0 &&
			this.userModel.currency.length > 0
		);
	}

	isValidCurrency(): boolean {
		if (this.userModel.currency != null) {
			return this.validCurrencies.includes(this.userModel.currency);
		}
		return false;
	}

	onSubmit() {
		throw new Error('Method not implemented.');
	}

	
}
