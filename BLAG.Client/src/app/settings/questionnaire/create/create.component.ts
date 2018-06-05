import { Component, OnInit } from '@angular/core';
import * as $ from 'jquery';

@Component({
  selector: 'app-create-questionnaire-view',
  templateUrl: './create.component.html',
  styleUrls: ['./create.component.css']
})
export class CreateComponentQuestionnaire implements OnInit {

  constructor() { }

  ngOnInit() {
    $(document).ready(function(){
      $('#btnRight').click(function (e) {
        var selectedOpts = $('#ListofQuestions option:selected');
        if (selectedOpts.length == 0) {
          alert("Nothing to move.");
          e.preventDefault();
        }
        $('#SelectedQuestions').append($(selectedOpts).clone());
        $(selectedOpts).remove();
        e.preventDefault();
      });
      $('#btnLeft').click(function (e) {
        var selectedOpts = $('#SelectedQuestions option:selected');
        if (selectedOpts.length == 0) {
          alert("Nothing to move.");
          e.preventDefault();
        }
        $('#ListofQuestions').append($(selectedOpts).clone());
        $(selectedOpts).remove();
        e.preventDefault();
      });
    });
  }

}
