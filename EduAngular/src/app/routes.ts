import { Routes } from '@angular/router'
import { HomeComponent } from './home/home.component';
import { UserComponent } from './user/user.component';
import { SignUpComponent } from './user/sign-up/sign-up.component';
import { SignInComponent } from './user/sign-in/sign-in.component';
import { AuthGuard } from './auth/auth.guard';
import { AdminPanelComponent } from './admin-panel/admin-panel.component';
import { ForbiddenComponent } from './forbidden/forbidden.component';
import { StartComponent } from './start/start.component';
import { SettingsComponent } from './settings/settings.component';
import { CoursesComponent } from './courses/courses.component';
import { LectionsComponent } from './lections/lections.component';
import { TestsComponent } from './tests/tests.component';
import { StudentsComponent } from './students/students.component';
import { TeachersComponent } from './teachers/teachers.component';
import { PerformanceComponent } from './performance/performance.component';
 
export const appRoutes: Routes = [
    { path: 'home', component: HomeComponent, canActivate:[AuthGuard] },
    { path: 'forbidden', component: ForbiddenComponent },
    { path: 'adminPanel', component: AdminPanelComponent, canActivate: [AuthGuard] , data: { roles: ['admin'] }},
    {
        path: 'signup', component: UserComponent,
        children: [{ path: '', component: SignUpComponent }]
    },
    {
        path: 'login', component: UserComponent,
        children: [{ path: '', component: SignInComponent }]
    },
    { path: '', redirectTo:'/start', pathMatch : 'full'},
    { path: 'start', component: StartComponent },
    { path: 'login', component: UserComponent },
    { path: 'settings', component: SettingsComponent, canActivate: [AuthGuard] , data: { roles: ['student','visitor','teacher'] }},
    { path: 'courses', component: CoursesComponent, canActivate:[AuthGuard] },
    { path: 'lections', component: LectionsComponent, canActivate:[AuthGuard] },
    { path: 'tests', component: TestsComponent, canActivate:[AuthGuard] },
    { path: 'students', component: StudentsComponent, canActivate:[AuthGuard], data: { roles: ['student','teacher', 'admin'] }},
    { path: 'teachers', component: TeachersComponent, canActivate:[AuthGuard], data: { roles: ['student','teacher', 'admin'] } },
    { path: 'performance', component: PerformanceComponent, canActivate:[AuthGuard], data: { roles: ['student', 'admin'] }}
];