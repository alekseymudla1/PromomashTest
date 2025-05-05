export interface CreateUserRequest {
  email: string;
  password: string;
  confirmationGiven: boolean;
  countryId: number;
  provinceId: number;
}
