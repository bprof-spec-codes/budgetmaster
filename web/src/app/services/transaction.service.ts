import { Injectable } from '@angular/core';
import { environment } from '../../environments/environment.development';
import { HttpClient } from '@angular/common/http';
import { Transaction } from '../models/transaction.model';

@Injectable({
  providedIn: 'root'
})
export class TransactionService {
  transactions: Transaction[] = [];
  baseUrl = environment.apiBaseUrl;

  constructor(private http: HttpClient) {
    this.loadApi();

  }

  public loadApi(): void{
    this.http.get<Transaction[]>(this.baseUrl + 'transaction').subscribe(data =>{
      this.transactions = data
    });
  }

  public create(transaction: Transaction): void {
    this.http.post(this.baseUrl + "transaction", transaction).subscribe({
      next: (response) => {
        console.log(".:SUCCESS:.")
        console.log("Create request result:", response)
        this.transactions.push(transaction)
      },
      error: (error) => {
        console.log(".:ERROR:.")
        console.log("Create request result:", error)
      }
    })
  }
}
