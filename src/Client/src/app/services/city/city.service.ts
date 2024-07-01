import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { CityWeather } from '../weather/weather.service';
import { Observable } from 'rxjs';

interface City {
  id: number;
  name: string;
  country: string;

}

@Injectable({
  providedIn: 'root'
})
export class CityService {

  
  private apiUrl = "http://localhost:5129/api/city"

  constructor(private http: HttpClient) { }


  getAll(): Observable<City[]> {
    return this.http.get<City[]>(`${this.apiUrl}`);
  }

  add(city: string): Observable<any> {
    return this.http.post(`${this.apiUrl}`, {Name: city});
  }

  remove(id: number): Observable<any> {
    return this.http.delete(`${this.apiUrl}/${id}`);
  }

}