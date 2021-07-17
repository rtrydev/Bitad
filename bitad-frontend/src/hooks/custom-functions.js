import layout from "../assets/css/Layout.module.css";
import bg from "../assets/css/Backgrounds.module.css";
import defaultPicture from "../assets/images/default-picture.svg";

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

/**
 * @param {Boolean} isNoScroll
 */
export const setNoScroll = (isNoScroll = false) => {
  const html = document.querySelector("html");
  isNoScroll
    ? html.classList.add(layout["no-scroll"])
    : html.classList.remove(layout["no-scroll"]);
};

/**
 * @param {string} accentColor
 */
export const accentColorToClassName = (accentColor) => {
  switch (accentColor) {
    case "pink":
      return bg.pink;
    case "green":
      return bg.green;
    case "purple":
    default:
      return bg.purple;
  }
};

/**
 * @param {string} pictureUrl
 */
export const parsePicture = (pictureUrl) => {
  return pictureUrl === "" ? defaultPicture : pictureUrl;
};
