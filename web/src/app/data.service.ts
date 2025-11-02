import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { delay, Observable, of } from 'rxjs';
import { User } from './models/usermodel';

@Injectable({
  providedIn: 'root'
})
export class DataService {

  constructor(private http: HttpClient) { }

	getUserData(userId: string) {
		return this.http.get(`/api/users/${userId}`);
	}

	getUsetProfilPicture(userId: string) : string
	{
		if(userId===null || userId =='')
		{
			userId = (Math.floor(Math.random()*99)+1).toString();
		}
		return `https://randomuser.me/api/portraits/men/${userId}.jpg`;
	}

	getAvaibleProfilPicture(): Observable<string[]> {
  	const numbersAsStrings = Array.from({ length: 99 }, (_, i) => (i + 1).toString());
  	return of(numbersAsStrings).pipe(delay(1000));
	}


	getUser(): Observable<User> {
    const userModel: User = {
      id: 'u001',
      email: 'pelda@example.com',
      firstName: 'Krisztián',
      lastName: 'Példa',
      phoneNumber: '123-456-7890',
      userType: 'Personal',
      currency: 'HUF',
      organizationId: null,
      createdAt: '2023-01-01T00:00:00Z',
      lastLogin: '2024-01-02T00:00:00Z',
	  picture: 'https://randomuser.me/api/portraits/men/1.jpg'
    };
    return of(userModel).pipe(delay(1000));
  }

}
