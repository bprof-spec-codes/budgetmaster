import { Component } from '@angular/core';
import { Transaction } from '../models/transaction.model';
import { Router } from '@angular/router';
import { TransactionService } from '../services/transaction.service';

@Component({
  selector: 'app-test',
  standalone: false,
  templateUrl: './test.html',
  styleUrl: './test.sass'
})
export class Test {
  transactions: Transaction[] = [];

  constructor(private router: Router, 
    public transactionService: TransactionService) {  
  }

  ngOnInit(): void {
    this.transactions = this.transactionService.transactions;
  }

  public create(): void{
    this.router.navigate(["/create/"])
  }
}
