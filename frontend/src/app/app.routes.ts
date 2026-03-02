import { Routes } from '@angular/router';
import { SignIn } from './pages/sign-in/sign-in';
import { Home } from './pages/home/home';  // 引入 Home component

export const routes: Routes = [
  { path: '', redirectTo: '/sign-in', pathMatch: 'full' },
  { path: 'sign-in', component: SignIn },
  { path: 'home', component: Home },   // 新增 Home 路由
];
