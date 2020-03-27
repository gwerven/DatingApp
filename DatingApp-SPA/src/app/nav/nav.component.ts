import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-nav',
  templateUrl: './nav.component.html',
  styleUrls: ['./nav.component.css']
})
export class NavComponent implements OnInit {
  // Create model object of type any and set it to an empty object
  // Stores username and password from form
  model: any = {};

  constructor() { }

  ngOnInit() {
  }

  // Login method
  login() {
    console.log(this.model);
  }

}
