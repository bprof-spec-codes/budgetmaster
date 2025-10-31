export interface BudgetModel {
  id: number;
  userId: string;
  organizationId?: number;
  categoryId: number;
  amountLimit: number;
  currency: string;
  year: number;
  month?: number;
  quarter?: number;
  alertEnabled: boolean;
  alertThresholdPercent: number;
  createdAt: Date;
  updatedAt: Date;
}