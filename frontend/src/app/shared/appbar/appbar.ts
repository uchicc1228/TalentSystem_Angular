import { Component } from '@angular/core';
import { Router, RouterModule } from '@angular/router';
import { NzLayoutModule } from 'ng-zorro-antd/layout';
import { NzMenuModule } from 'ng-zorro-antd/menu';
import { NzMessageService } from 'ng-zorro-antd/message'; // 新增
import { CommonModule } from '@angular/common';
import { AuthService } from '../../services/auth';

@Component({
  selector: 'app-appbar',
  standalone: true,
  imports: [CommonModule, RouterModule, NzLayoutModule, NzMenuModule],
  templateUrl: './appbar.html',
  styleUrls: ['./appbar.css']
})
export class Appbar {
  constructor(
    public authService: AuthService,
    private message: NzMessageService,   // 新增
    private router: Router               // 新增
  ) {}

  logout(): void {
    this.authService.logout();
    this.message.info('已登出');
    this.router.navigate(['/sign-in']);
  }
}
