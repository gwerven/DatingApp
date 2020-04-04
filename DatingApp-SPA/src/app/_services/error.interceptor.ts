import { Injectable } from '@angular/core';
import { HttpInterceptor, HttpErrorResponse, HTTP_INTERCEPTORS } from '@angular/common/http';
import { throwError } from 'rxjs';
import { catchError } from 'rxjs/operators';

@Injectable()
export class ErrorInterceptor implements HttpInterceptor {
  // Intercept the request and catch any errors (in 400 or 500 range)
  intercept(
    req: import('@angular/common/http').HttpRequest<any>,
    next: import('@angular/common/http').HttpHandler
  ): import('rxjs').Observable<import('@angular/common/http').HttpEvent<any>> {
    return next.handle(req).pipe(
        catchError(error => {
            // 400 level errors
            if(error.status === 401) {
                return throwError(error.statusText);
            }
            // 500 level errors
            if(error instanceof HttpErrorResponse) {
                // Application errors are 500 internal server errors
                const applicationError = error.headers.get('Application-Error');
                if(applicationError) {
                    return throwError(applicationError);
                }
                const serverError = error.error;
                // Modal state errors include pw too short, validation reqs not met
                let modalStateErrors = '';
                // Check if the errors exist and that they're a type of object
                if(serverError.errors && typeof serverError.errors === 'object') {
                    for(const key in serverError.errors) {
                      // Get the error with the key defined here
                      if(serverError.errors[key]) {
                        // Build a list of strings separated by new lines for each error
                        modalStateErrors += serverError.errors[key] + '\n';
                      }
                    }
                }
                // If no modal state errors, throw server error, if none then return message 'Server Error'
                return throwError(modalStateErrors || serverError || 'Server Error');
            }
        })
    );
  }
}

export const ErrorInterceptorProvider = {
  provide: HTTP_INTERCEPTORS,
  useClass: ErrorInterceptor,
  // Can have multiple interceptors
  multi: true
};