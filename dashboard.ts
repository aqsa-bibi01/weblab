

import { Component, OnInit } from '@angular/core';
import { RequestService } from '../services/request.service';

@Component({
  selector: 'app-dashboard',
  templateUrl: './dashboard.component.html'
})
export class DashboardComponent implements OnInit {

  requests: any[] = [];

  constructor(private service: RequestService) {}

  ngOnInit(): void {
    this.loadRequests();
  }

  loadRequests() {
    this.service.getRequests().subscribe(data => {
      this.requests = data;
    });
  }

  deleteRequest(id: string) {
    this.service.deleteRequest(id).subscribe(() => {
      this.loadRequests();
    });
  }
}