import { Component, OnInit, ViewChild, AfterViewInit } from '@angular/core';
import { DataEnergyService } from '../data-energy.service';
import { MatTableDataSource } from '@angular/material/table';
import { MatPaginator } from '@angular/material/paginator';

@Component({
  selector: 'app-data-energy',
  templateUrl: './data-energy.component.html',
  styleUrls: ['./data-energy.component.css'],
})
export class DataEnergyComponent implements OnInit, AfterViewInit {
  dataEnergy: MatTableDataSource<any> = new MatTableDataSource<any>();
  displayedColumns: string[] = ['id', 'company_id', 'consumer_unity', 'value', 'timestamp'];

  @ViewChild(MatPaginator) paginator!: MatPaginator;

  constructor(private dataEnergyService: DataEnergyService) { }

  ngOnInit(): void {
    this.dataEnergyService.getData().subscribe((data: any[]) => {
      this.dataEnergy.data = data;
    });
  }

  ngAfterViewInit(): void {
    this.dataEnergy.paginator = this.paginator;
  }
}
