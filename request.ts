import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root',
})
export class Request {}
export interface Request {
  id?: string;
  clientName: string;
  email: string;
  serviceType: string;
  projectDescription: string;
  budget: number;
  status: string;
}