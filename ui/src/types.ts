export interface Court {
  courtId?: string;
  label: string;
  bookings: Booking[];
}

export interface Booking {
  bookingId?: string;
  courtId: string;
  type: "BOOKED" | "BLOCKED";
  firstName?: string;
  lastName?: string;
  date: string;
  startTime: number;
  endTime: number;
}
