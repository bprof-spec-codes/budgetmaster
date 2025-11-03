export interface User {
  id: string;
  email: string;
  firstName: string;
  lastName: string;
  phoneNumber: string | null;
  userType: string;
  currency: string;
  organizationId: number | null;
  createdAt: string;
  lastLogin: string;
  picture: string;
}


// export enum UserType {
//   Admin = 0,
//   Manager = 1,
//   Employee = 2,
//   User = 3
// }