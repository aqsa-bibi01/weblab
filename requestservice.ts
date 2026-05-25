import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { Request } from '../models/request';

@Injectable({
  providedIn: 'root'
})
export class RequestService {

  apiUrl = 'https://localhost:xxxx/api/requests';

  constructor(private http: HttpClient) {}

  getRequests(): Observable<Request[]> {
    return this.http.get<Request[]>(this.apiUrl);
  }

  addRequest(data: Request): Observable<Request> {
    return this.http.post<Request>(this.apiUrl, data);
  }

  updateRequest(id: string, data: Request) {
    return this.http.put(`${this.apiUrl}/${id}`, data);
  }

  deleteRequest(id: string) {
    return this.http.delete(`${this.apiUrl}/${id}`);
  }
}