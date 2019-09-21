import { Injectable } from '@angular/core';
import { Hotel } from './hotel';
import { Observable, from } from 'rxjs';

@Injectable()
export class HotelStaticDataSource {
    private hotels: Hotel[] = [
        new Hotel(1, "Lakewood", "Watersports", "A simple hotel", 100),
        new Hotel(2, "Bridgewood", "Watersports", "A sofisticated hotel", 300),
        new Hotel(3, "Ridgewood", "Watersports", "A greatful hotel", 500)
    ];

    getHotels(): Observable<Hotel[]> {
        return from([this.hotels]);
    }
}