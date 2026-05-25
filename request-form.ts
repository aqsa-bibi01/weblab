import { Component } from '@angular/core';
import { FormBuilder, Validators } from '@angular/forms';
import { RequestService } from '../services/request.service';

@Component({
  selector: 'app-request-form',
  templateUrl: './request-form.component.html'
})
export class RequestFormComponent {

  constructor(
    private fb: FormBuilder,
    private service: RequestService
  ) {}

  requestForm = this.fb.group({
    clientName: ['', Validators.required],
    email: ['', [Validators.required, Validators.email]],
    serviceType: ['', Validators.required],
    projectDescription: ['', Validators.required],
    budget: [0, Validators.min(1000)]
  });

  submit() {

    if(this.requestForm.valid) {

      this.service.addRequest(
        this.requestForm.value as any
      ).subscribe(() => {

        alert("Request Submitted");
        this.requestForm.reset();
      });
    }
  }
}