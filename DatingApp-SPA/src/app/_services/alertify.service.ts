import { Injectable } from '@angular/core';
import * as alertify from 'alertifyjs';

@Injectable({
  providedIn: 'root'
})
export class AlertifyService {

constructor() { }

  // Confirm message notification
  confirm(message: string, okCallback: () => any) {
    alertify.confirm(message, (e: any) => {
      if(e) {
        okCallback();
      } else {}
    });
  }
  
  // Success message notification
  success(message: string) {
    alertify.success(message);
  }

  // Error message notification
  error(message: string) {
    alertify.error(message);
  }

  // Warning message notification
  warning(message: string) {
    alertify.warning(message);
  }

  // Message notification
  message(message: string) {
    alertify.message(message);
  }
}
