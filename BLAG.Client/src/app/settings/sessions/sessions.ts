import { Time } from '@angular/common';

export class Session {
  id: number;
  joinCode: string;
  CurrentQuestionIndex: number;
  Questionnaire: any;
  StartTime: Time;
}