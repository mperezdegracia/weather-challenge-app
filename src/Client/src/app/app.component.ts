import { CommonModule } from '@angular/common';
import { Component } from '@angular/core';
import { RouterLink, RouterOutlet } from '@angular/router';



@Component({
  selector: 'app-root',
  standalone: true,
  templateUrl: './app.component.html',
  imports: [ RouterLink, RouterOutlet],
  styleUrls: ['./app.component.css']
})
export class AppComponent  {
  
}