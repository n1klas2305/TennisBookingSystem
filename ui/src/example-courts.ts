import type { Court } from "./types";

export const exampleCourts: Court[] = [
  {
    label: "Platz 1",
    bookings: [
      {
        firstName: "Hetty",
        lastName: 'Deacon',
        day: "2022-11-24",
        startTime: 12,
        endTime: 14,
        type: "BOOKED",
      },
      {
        firstName: "Oisin",
        lastName: "Clements",
        day: "2022-11-25",
        startTime: 9,
        endTime: 10,
        type: "BOOKED",
      },
      {
        firstName: "Maaria",
        lastName: "Garza",
        day: "2022-11-26",
        startTime: 14,
        endTime: 15,
        type: "BOOKED",
      },
      {
        day: "2022-11-26",
        startTime: 17,
        endTime: 18,
        type: "BLOCKED",
      },
    ],
  },
  { label: "Platz 2", bookings: [] },
  {
    label: "Platz 3", bookings: [{
      firstName: "Lili",
      lastName: "Wilkes",
      day: "2022-11-24",
      startTime: 11,
      endTime: 14,
      type: "BOOKED",
    },
    {
      day: "2022-11-26",
      startTime: 10,
      endTime: 22,
      type: "BLOCKED",
    },]
  },
  { label: "Platz 4", bookings: [] },
];
