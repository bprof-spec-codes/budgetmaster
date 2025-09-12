import { Component } from '@angular/core';
import { Router } from '@angular/router';
import { TransactionService } from '../services/transaction.service';
import { Transaction } from '../models/transaction.model';

@Component({
  selector: 'app-createtransaction',
  standalone: false,
  templateUrl: './createtransaction.html',
  styleUrl: './createtransaction.sass'
})
export class Createtransaction {

  transaction: Transaction = new Transaction();
  constructor(private router: Router,
    public transactionService: TransactionService
  ) {
  
  }

public clickSave(): void{
  this.transactionService.create(this.transaction);
    this.router.navigate(["/home"])
}
}
