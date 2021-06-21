import React from "react";
import Sponsor from "./Sponsor";

const SAMPLE_SPONSORS = [
  {
    rank: 0,
    name: "Google",
    picture:
      "https://www.google.com/images/branding/googlelogo/2x/googlelogo_color_272x92dp.png",
    webpage: "https://www.google.com",
  },
];

function Sponsors() {
  const sponsors = SAMPLE_SPONSORS.map((sponsor) => {
    return (
      <Sponsor
        key={sponsor.name}
        webpage={sponsor.webpage}
        picture={sponsor.picture}
        name={sponsor.name}
      />
    );
  });

  return <div>{sponsors}</div>;
}

export default Sponsors;
