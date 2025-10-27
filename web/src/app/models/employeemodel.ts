export interface Employee {
  id: number;
  organizationId: number;
  createdByUserId: string;
  firstName: string;
  lastName: string;
  email?: string;
  phone?: string;
  employmentType: EmploymentType;
  position?: string;
  taxId?: string;
  startDate: Date;
  endDate?: Date;
  isActive: boolean;
  createdAt: Date;
  updatedAt: Date;
  fullName: string;
  employmentTypeDisplay: string;
}

export enum EmploymentType {
  Employee = 0,
  Contractor = 1
}