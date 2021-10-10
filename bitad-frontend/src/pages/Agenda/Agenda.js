import SmallHero from "../../components/Hero/SmallHero";
import Section from "../../components/UI/Section";
import EventsPart from "./EventsPart";
import TimelinesPart from "./TimelinesPart";
import { useGetRequest } from "../../hooks/http-requests";

import typography from "../../assets/css/Typography.module.css";
import heroImage from "../../assets/images/bitad-logo.svg";
import Loading from "../../components/UI/Loading";

function Agenda() {
  const { response: agendas, isLoading: isLoadingAgendas } =
    useGetRequest("/Agenda/GetAgendas");
  const { response: workshops, isLoading: isLoadingWorkshops } = useGetRequest(
    "/Workshop/GetWorkshops"
  );

  const events =
    isLoadingAgendas || isLoadingWorkshops ? (
      <Loading fontSize="120px" />
    ) : (
      <>
        <TimelinesPart agendas={agendas} workshops={workshops} />
        <EventsPart agendas={agendas} workshops={workshops} />
      </>
    );

  return (
    <div>
      <SmallHero
        imageSrc={heroImage}
        imageAlt="Logo konferencji"
        subtitle="19 listopada 2021, na terenie uczelni ATH w Bielsku-Białej"
        title="Konferencja Informatyczna"
        linkText="Zapisz się już dziś!"
        linkTo="/registration"
      />
      <Section id="agenda">
        <h2 className={typography["text-align--center"]}>Agenda</h2>
        {events}
      </Section>
    </div>
  );
}

export default Agenda;
