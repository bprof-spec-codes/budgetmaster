export interface Organization {
  id: number;
  name: string;
  taxNumber?: string;
  address?: string;
  contactEmail?: string;
  contactPhone?: string;
  orgType: OrganizationType;
  createdAt: Date;
  updatedAt: Date;
}

export enum OrganizationType {
  Individual = 0,
  SmallBusiness = 1,
  Corporation = 2,
  NonProfit = 3
}