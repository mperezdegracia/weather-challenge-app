import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { CityService } from '../../services/city/city.service';
import { CommonModule } from '@angular/common';
import { ReactiveFormsModule } from '@angular/forms';
import { DropdownModule } from 'primeng/dropdown';
import { CheckboxModule } from 'primeng/checkbox';
import { ButtonModule } from 'primeng/button';
import { TableModule } from 'primeng/table';

@Component({
  selector: 'app-city',
  standalone: true,
  imports: [

    CommonModule,
    ReactiveFormsModule,
    DropdownModule,
    CheckboxModule,
    ButtonModule,
    TableModule

  ],
  templateUrl: './city.component.html',
  styleUrl: './city.component.css'
})
export class CityComponent implements OnInit {
    cities: any[] = [];
    loading: boolean = false;
  
    constructor(private cityService: CityService,private router: Router ) { }
  
    ngOnInit(): void {
      this.loadCities();
    }
  
    goToCities(): void {
      this.router.navigate(['/cities']);
    }
    
    loadCities(): void {
      this.cityService.getAll().subscribe(
        cities => {
          this.cities = cities;
        },
        error => {
          console.error('Error loading cities:', error);
        }
      );
    }
    addCity(city: string, country: string): void {
      this.cityService.add(city, country).subscribe(
        () => {
          this.loadCities(); // Refresh cities list after addition
        },
        error => {
          console.error('Error adding city:', error);
        }
      );
    }
  
    removeCity(id: number): void {
      this.cityService.remove(id).subscribe(
        () => {
          this.loadCities(); // Refresh cities list after removal
        },
        error => {
          console.error('Error removing city:', error);
        }
      );
    }
  
  


}
