import { Component, OnInit, ChangeDetectorRef } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { NzTableModule } from 'ng-zorro-antd/table';
import { NzButtonModule } from 'ng-zorro-antd/button';
import { NzInputModule } from 'ng-zorro-antd/input';
import { Router } from '@angular/router'; // 新增
import { TalentService } from '../../services/talent';
import { AuthService } from '../../services/auth';
import { TalentInfo } from '../../Models/TalentInfo';

@Component({
  selector: 'app-home',
  standalone: true,
  imports: [CommonModule, FormsModule, NzTableModule, NzButtonModule, NzInputModule],
  templateUrl: './home.html',
  styleUrls: ['./home.css'],
})
export class Home implements OnInit {
  listOfData: TalentInfo[] = [];
  searchText: string = '';
  pageIndex = 1;
  pageSize = 10;
  total = 0;

  constructor(
    private talentService: TalentService,
    private cdr: ChangeDetectorRef,
    private authService: AuthService,
    private router: Router // 新增
  ) {}

  ngOnInit(): void {
    if (this.authService.isLoggedIn()) {
      this.loadData();
    } else {
      this.router.navigate(['/sign-in']);
    }
  }

  loadData(): void {
    this.talentService.getAllTalents(this.pageIndex, this.pageSize, this.searchText).subscribe({
      next: (data: { items: TalentInfo[]; total: number }) => {
        this.listOfData = data.items;
        this.total = data.total;
        this.cdr.detectChanges();
      },
      error: (err) => console.error('[Home] API error:', err),
    });
  }

  onSearch(): void {
    this.pageIndex = 1;
    this.loadData();
  }

  onPageIndexChange(index: number): void {
    this.pageIndex = index;
    this.loadData();
  }

  onPageSizeChange(size: number): void {
    this.pageSize = size;
    this.loadData();
  }
}
