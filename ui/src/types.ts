export interface Court {
  id?: string;
  label: string;
  bookings: Booking[];
}

export interface Booking {
  id?: string;
  type: "BOOKED" | "BLOCKED";
  firstName?: string;
  lastName?: string;
  day: string;
  startTime: number;
  endTime: number;
}