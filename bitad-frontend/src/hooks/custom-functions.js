/**
 *
 * @param {string} className
 * @returns
 */
export const parseClassName = (className) => {
  if (className === undefined) return "";

  const newClassNames = className.split(" ").filter((className) => {
    if (className === "false" || className === "true") return false;
    return true;
  });

  return newClassNames.join(" ");
};
