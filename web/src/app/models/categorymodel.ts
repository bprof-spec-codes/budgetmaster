export interface Category {
  id: number;
  name: string;
  description?: string;
  categoryType: CategoryType;
  icon?: string;
  color?: string;
  isDefault: boolean;
  organizationId?: number;
  createdAt: Date;
}

export enum CategoryType {
  Income = 0,
  Expense = 1,
  Transfer = 2
}