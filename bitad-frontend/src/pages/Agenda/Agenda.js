import SmallHero from "../../components/Hero/SmallHero";
import Section from "../../components/UI/Section";
import EventsPart from "./EventsPart";
import TimelinesPart from "./TimelinesPart";

import typography from "../../assets/css/Typography.module.css";
import heroImage from "../../assets/images/bitad-logo.svg";

function Agenda() {
  return (
    <div>
      <SmallHero
        imageSrc={heroImage}
        imageAlt="Logo konferencji"
        subtitle="20 marca 2020, na terenie uczelni ATH w Bielsku-Białej"
        title="Konferencja Informatyczna"
        linkText="Zapisz się już dziś!"
        linkTo="/"
      />
      <Section>
        <h2 id="agenda" className={typography["text-align--center"]}>
          Agenda
        </h2>
        <TimelinesPart />
        <EventsPart />
      </Section>
    </div>
  );
}

export default Agenda;
