import { Category } from "../enums/category.enum"

export class Transaction {
    id: number = 0
    amount: number = 0
    category: Category = Category.Food
    date: Date = new Date()
    note: string = ''
    earning: boolean = false
}