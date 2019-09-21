import { Injectable } from '@angular/core';
import { HotelStaticDataSource } from './hotel.static.datasource';
import { Hotel } from './hotel';

@Injectable()
export class HotelRepository {
    private hotels: Hotel[] = [];
    private categories: string[] = [];

    constructor(private dataSource: HotelStaticDataSource) {
        dataSource.getHotels().subscribe(hotels => {
            this.hotels = hotels;
            this.categories = hotels.map(h => h.category)
                .filter((c, index, array) => array.indexOf(c) == index).sort();
        });
    }

    getHotels(): Hotel[] {
        return this.hotels;
    }

    getHotel(id: number): Hotel {
        return this.hotels.find(h => h.id == id);
    }
}