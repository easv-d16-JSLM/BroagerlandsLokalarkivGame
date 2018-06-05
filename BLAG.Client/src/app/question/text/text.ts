import { QuestionTypes } from "../question-types.enum";

export class Text {
    points: number;
    questionnaire: {title: string;};
    time: number;
    content: string;
    questiontypes: QuestionTypes;
    id: number;
  }