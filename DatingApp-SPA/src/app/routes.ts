import { Routes } from '@angular/router';
import { HomeComponent } from './home/home.component';
import { MemberListComponent } from './members/member-list/member-list.component';
import { MessagesComponent } from './messages/messages.component';
import { ListsComponent } from './lists/lists.component';
import { AuthGuard } from './_guards/auth.guard';
import { MemberDetailComponent } from './members/member-detail/member-detail.component';
import { MemberDetailResolver } from './_resolvers/member-detail.resolver';
import { MemberListResolver } from './_resolvers/member-list.resolver';
import { MemberEditComponent } from './members/member-edit/member-edit.component';
import { MemberEditResolver } from './_resolvers/member-edit.resolver';

export const appRoutes: Routes = [
    // Default empty path is home page
    { path: '', component: HomeComponent },
    {
        // Dummy route using one route guard to protect multiple child routes
        path: '',
        runGuardsAndResolvers: 'always',
        canActivate: [AuthGuard],
        children: [
            { path: 'members', component: MemberListComponent, resolve: {users: MemberListResolver}, canActivate: [AuthGuard] },
            { path: 'members/:id', component: MemberDetailComponent, resolve: {user: MemberDetailResolver}, canActivate: [AuthGuard] },
            { path: 'member/edit', component: MemberEditComponent , resolve: {user: MemberEditResolver}, canActivate: [AuthGuard] },
            { path: 'messages', component: MessagesComponent },
            { path: 'lists', component: ListsComponent }
        ]
    },
    // If user types in anything other than a defined route, redirect them to the home page
    { path: '**', redirectTo: '', pathMatch: 'full'}
];
