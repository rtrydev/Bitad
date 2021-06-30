import moment from "moment";

/**
 *
 * @param {moment} testTime
 * @param {moment} time
 * @returns
 */
export const isBeforeTime = (testTime, time) => {
  if (time.hour() < testTime.hour()) return false;
  if (time.hour() > testTime.hour()) return true;
  if (time.minute() > testTime.minute()) return true;
  return false;
};

/**
 *
 * @param {moment} testTime
 * @param {moment} time
 * @returns
 */
export const isAfterTime = (testTime, time) => {
  if (time.hour() > testTime.hour()) return false;
  if (time.hour() < testTime.hour()) return true;
  if (time.minute() < testTime.minute()) return true;
  return false;
};

/**
 *
 * @param {moment} testTime
 * @param {moment} time
 * @returns
 */
export const isSameTime = (testTime, time) => {
  if (time.hour() === testTime.hour() && time.minute() === testTime.minute())
    return true;
  return false;
};

/**
 *
 * @param {Object} events
 * @param {moment} startTime
 * @param {moment.duration} duration
 * @returns
 */
export const filterEventsByTime = (
  events,
  startTime,
  duration = moment.duration(270, "minutes")
) => {
  const filteredEvents = events.filter((event) => {
    const start = moment(event.start);
    const end = moment(event.end);
    const sTime = moment(startTime);
    const endTime = moment(sTime).add(duration);

    if (!isBeforeTime(start, sTime) && isBeforeTime(start, endTime))
      return true;
    if (!isBeforeTime(end, sTime) && isBeforeTime(end, endTime)) return true;

    return false;
  });

  return filteredEvents;
};

/**
 *
 * @param {moment} startTime
 * @param {moment.duration} duration
 * @param {number} minutesIncrement
 * @returns
 */
export const createTimes = (
  startTime,
  minutesIncrement = 30,
  duration = moment.duration(270, "minutes")
) => {
  const times = [];

  if (!moment.isMoment(startTime)) return times;

  const endTime = moment(startTime).add(duration);
  let currentTime = moment(startTime);

  while (!currentTime.isAfter(endTime)) {
    times.push(moment(currentTime));
    currentTime.add(minutesIncrement, "minutes");
  }
  return times;
};
