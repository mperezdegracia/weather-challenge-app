import { Component, OnInit } from '@angular/core';
import { Router, RouterModule } from '@angular/router';
import { CityService } from '../../services/city/city.service';
import { CommonModule } from '@angular/common';
import { ReactiveFormsModule } from '@angular/forms';
import { DropdownModule } from 'primeng/dropdown';
import { CheckboxModule } from 'primeng/checkbox';
import { ButtonModule } from 'primeng/button';
import { TableModule } from 'primeng/table';
import { InputTextModule } from 'primeng/inputtext';
import { FormsModule } from '@angular/forms';
import { ToastModule } from 'primeng/toast';
import { MessageService } from 'primeng/api';
@Component({
  selector: 'app-city',
  standalone: true,
  imports: [

    CommonModule,
    ReactiveFormsModule,
    DropdownModule,
    CheckboxModule,
    ButtonModule,
    TableModule,
    RouterModule,
    InputTextModule,
    FormsModule,
    ToastModule

  ],
  providers: [MessageService],
  templateUrl: './city.component.html',
  styleUrl: './city.component.css'
})
export class CityComponent implements OnInit {


  cities: any[] = [];
  loading: boolean = false;
  city: string = '';
  addError: string = '';
  deleteError: string = '';
  constructor(private cityService: CityService, private router: Router, private messageService: MessageService) { }

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
  addCity(city: string): void {
    this.cityService.add(city).subscribe(
      (response) => {
        console.log(response); // Puedes usar la respuesta si necesitas
        this.loadCities(); // Refresh cities list after addition
        this.city = ''; // Limpia el campo de entrada después de agregar la ciudad
        this.messageService.add({ severity: 'success', summary: 'Success', detail: 'City added' })
      },
      error => {
        this.addError = error.error.message;
        this.messageService.add({ severity: 'error', summary: 'Error', detail: `${city} is not available or is already added`})
        console.error('Error adding city:', error);
      }
    );
  }

  deleteCity(id: number): void {
    this.cityService.remove(id).subscribe(
      () => {
        this.loadCities(); // Refresh cities list after removal
        this.messageService.add({ severity: 'success', summary: 'Success', detail: `Successfully removed city`})

      },
      error => {
        this.deleteError = error.error.message;
        this.messageService.add({ severity: 'error', summary: 'Error', detail: `Failed to remove city`})

        console.error('Error removing city:', error);
      }
    );
  }




}
