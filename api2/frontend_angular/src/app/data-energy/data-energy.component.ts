import { Component, OnInit } from '@angular/core';
import { DataEnergyService } from '../data-energy.service';

@Component({
    selector: 'app-data-energy',
    templateUrl: './data-energy.component.html',
    styleUrls: ['./data-energy.component.css']
})
export class DataEnergyComponent implements OnInit {

    dataEnergy: any[] = [];

    constructor(private dataEnergyService: DataEnergyService) { }

    ngOnInit(): void {
        this.dataEnergyService.getData().subscribe((data: any[]) => {
            this.dataEnergy = data;
        });
    }
    displayedColumns: string[] = ['id', 'company_id', 'consumer_unity', 'value', 'timestamp'];
}
