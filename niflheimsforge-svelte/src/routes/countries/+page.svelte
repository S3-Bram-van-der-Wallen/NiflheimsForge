<script lang="ts">
  import { onMount, onDestroy } from 'svelte';
  import { Button, Modal, ModalHeader, ModalBody, ModalFooter, Input, Label } from '@sveltestrap/sveltestrap';

  let isOpen = false;
  let modalOpen = false;
  let countryName = '';
  let countryDescription = '';
  export let countries = [];
  let selectedCountry = null;
  
  onMount(getCountries);

  function toggle() {
  isOpen = !isOpen;
  }

  function toggleModal() {
    modalOpen = !modalOpen;
  }

  async function getCountries() {
    const response = await fetch(`/countries`);
    if (response.ok) {
      let newCountries = await response.json();
      countries = newCountries.body;
      console.log(countries);
    } else {
      console.error('Failed to fetch countries')
    }
}

  async function getCountryBy(id) {
    console.log(id);
    const response = await fetch(`/countries/${id}`);
    if (response.ok) {
      const country = await response.json();
      // selectedCountry = country;
      console.log('Selected country:', selectedCountry);
    } else {
      console.error('Failed to fetch country, error status:', response.status);
    }
  }

  async function createCountry() {
    const countryDTO = {
      name: countryName,
      description: countryDescription
    };
    const response = await fetch ('/countries', {
      method: 'POST',
      headers: {
        'Content-Type': 'application/json'
      },
      body: JSON.stringify(countryDTO)
    });

    if (response.ok) {
      const country = await response.json();
      console.log('Country created:', country);
      toggleModal();
      await getCountries();
      return country;
    } else {
      const responseBody = await response.json();
      console.error(`Failed to create country page: ${responseBody.message}`);
    }
  }
</script>

<style>
  body, html {
  height: 100%;
  }
  .flex-container {
  display: flex;
  height: calc(100vh - 60px);
  }
  .country-navigation {
    flex: 0 0 20%;
    border-style: solid;
    border-width: 2px;
    border-color: green;
  }
  .country-content {
    flex: 1;
    display: flex;
    justify-content: flex-end;
  }
  .country-details {
    position: fixed;
    right: 750px;
  }
  .dnd-content-manager {
    flex: 0 0 0;
    display: flex;
    justify-content: flex-end;
    background-color: darkgray;
    transition: flex-basis 0.5s ease-in-out;
    overflow: hidden;
  }
  .dnd-content-manager.open {
    flex-basis: 20%
  }
  .topright-button {
    padding: 10px; 
    }
  .bottom-button {
    margin: auto;
    width: 100%;
    bottom: 10px;
    text-align: center;
  }
</style>

<div class="flex-container">
  <div class="country-navigation">
    All countries:
    <ul>
      {#each countries as country (country.id)}
      <a href='#' on:click={() => getCountryBy(country.id)}>{country.name}</a><br/>
      {/each}
    </ul>
    <div class="bottom-button">
      <Button color="success" on:click={toggleModal}>
        Create a new country
      </Button>
    </div>
  </div>
  <div class="country-content">
    <div class="country-details">
      {#if selectedCountry === null}
        <h1>Please choose a country</h1>
      {:else}
        <h1>selectedCountry.name</h1>
      {/if}
    </div>
    {#if !isOpen}
      <div class="topright-button">
          <Button on:click={toggle} color="success">
            <span>Manage your D&D content</span>
          </Button>
      </div>
    {/if}
  </div>
  <div class="dnd-content-manager {isOpen ? 'open' : ''}" id="dndContentManager">
    <div class="topright-button">
      <Button on:click={toggle} color="close">
      </Button>
    </div>
  </div>  
</div>

<Modal isOpen={modalOpen} toggle={toggleModal}>
  <ModalHeader toggle={toggleModal}>Create a new country</ModalHeader>
  <ModalBody>
    <Label for="countryName">Country Name</Label>
    <Input type="text" id="countryName" bind:value={countryName} placeholder="Enter country name" />
    <Label for="countryDescription">Country Description</Label>
    <Input type="text" id="countryDescription" bind:value={countryDescription} placeholder="Enter country description" />
  </ModalBody>
  <ModalFooter>
    <Button color="success" on:click={createCountry}>Create</Button>{' '}
    <Button color="danger" on:click={toggleModal}>Cancel</Button>
  </ModalFooter>
</Modal>