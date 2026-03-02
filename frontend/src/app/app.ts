import { Component } from '@angular/core';
import { RouterOutlet } from '@angular/router';
import { NzLayoutModule } from 'ng-zorro-antd/layout';
import { NzMenuModule } from 'ng-zorro-antd/menu';
import { Appbar } from './shared/appbar/appbar';
import { NzTableModule } from 'ng-zorro-antd/table';
@Component({
  selector: 'app-root',
  imports: [RouterOutlet, NzLayoutModule, NzMenuModule, Appbar, NzTableModule ],
  templateUrl: './app.html',
  styleUrl: './app.css'
})

export class App {}
