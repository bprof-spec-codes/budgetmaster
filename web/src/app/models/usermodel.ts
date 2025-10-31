export interface UserModel {
  id: string;
  userName?: string;
  email: string;
  firstName: string;
  lastName: string;
  phone?: string;
  userType: UserType;
  currency: string;
  isActive: boolean;
  organizationId?: number;
  createdAt: Date;
  updatedAt: Date;
  lastLogin?: Date;
  fullName: string;
}

export enum UserType {
  Admin = 0,
  Manager = 1,
  Employee = 2,
  User = 3
}