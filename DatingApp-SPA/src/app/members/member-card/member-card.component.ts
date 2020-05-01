import { Component, OnInit, Input } from '@angular/core';
import { User } from 'src/app/_models/user';

@Component({
  selector: 'app-member-card',
  templateUrl: './member-card.component.html',
  styleUrls: ['./member-card.component.css']
})
// MemberCardComponent is a child component of the MemberListComponent
export class MemberCardComponent implements OnInit {
  @Input() user: User;

  constructor() { }

  ngOnInit() {
  }

}
