import { Component, OnInit } from '@angular/core';
import { TeamsService } from '../_services/teams.service';
import { Team } from '../_models/team';

@Component({
  selector: 'app-teams',
  templateUrl: './teams.component.html',
  styleUrls: ['./teams.component.css']
})
export class TeamsComponent implements OnInit {
  teams: Team[];
  constructor(private teamsService : TeamsService) { }

  ngOnInit() {
    this.teamsService.getAll().subscribe(x => console.log(x));
  }

}
