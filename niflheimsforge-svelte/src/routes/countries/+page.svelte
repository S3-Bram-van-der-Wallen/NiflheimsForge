<script lang="ts">
  import { onMount } from 'svelte';
  import { 
    Button, 
    Modal, 
    ModalHeader, 
    ModalBody, 
    ModalFooter, 
    Input, 
    Label, 
    ListGroup, 
    ListGroupItem, 
    Dropdown,
    DropdownItem,
    DropdownMenu,
    DropdownToggle,
  } from '@sveltestrap/sveltestrap';

  let isOpen = false;
  let modalOpen = false;
  let filterModalOpen = false;
  let selectedCountry = null;
  export let countries = [];
  let countryName = '';
  let countryDescription = '';
  export let monsters = [];
  let monsterName = '';
  let CR;
  
  onMount(getCountries);

  function toggle() {
    isOpen = !isOpen;
    if (isOpen) {
      getMonsters();
    }
  }

  function toggleModal() {
    modalOpen = !modalOpen;
  }

  function toggleFilterModal() {
    filterModalOpen = !filterModalOpen;
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
      selectedCountry = country;
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

  async function getMonsters() {
    let url = '/monsters';
    const params = new URLSearchParams();

    if (monsterName) {
      params.append('MonsterName', monsterName);
    }

    if (CR) {
      params.append('CR', CR);
    }

    if (params.toString()) {
      url += `?${params.toString()}`;
    }

    const response = await fetch(url);
    if (response.ok) {
      let newMonsters = await response.json();
      monsters = newMonsters.body;
      console.log(monsters);
    } else {
      console.error('Failed to fetch monsters');
    }
  }

  async function applyFilters() {
    if (CR < 0 || CR > 30) {
      alert("CR value must be between 0 and 30.");
      return;
    }
    getMonsters();
    toggleFilterModal();
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
    justify-content: flex-start;
    flex-direction: column;
    border-style: solid;
    border-width: 2px;
    border-color: green;
  }
  .country-title {
    display: flex;
    width: 100%;
    justify-content: space-between;
    height: 50px;
    padding: 10px;
  }
  .dnd-content-manager {
    flex: 0 0 0;
    display: flex;
    justify-content: flex-end;
    transition: flex-basis 0.5s ease-in-out;
    overflow: hidden;
  }
  .dnd-content-manager.open {
    flex-basis: 20%;
    flex-direction: column;
    overflow: hidden;
    border-style: solid;
    border-width: 2px;
    border-color: green;
  }
  .bottom-button {
    padding: 10px;
    margin: auto;
    width: 100%;
    bottom: 10px;
    text-align: center;
  }
  .dnd-content-button {
    padding: 10px;
    position: sticky;
    top: 0;
    background-color: inherit;
    z-index: 1;
    text-align: center;
  }
  .dnd-content-list {
    overflow-y: auto;
    flex-grow: 1; 
    padding: 5px;
}
.country-details {
  padding: 10px;
}
.dnd-content-filtering {
  
  display: flex;
  flex-direction: row;
  justify-content: space-between;
}
</style> 

<div class="flex-container">
  <div class="country-navigation">
    <ListGroup>
      <ListGroupItem color="success">All countries</ListGroupItem>
      {#each countries as country (country.id)}
      <ListGroupItem on:click={() => getCountryBy(country.id)} action>{country.name}</ListGroupItem>
      {/each}
      </ListGroup>
        <div class="bottom-button">
          <Button color="success" on:click={toggleModal}>
            Create a new country
          </Button>
        </div>
  </div>
    <div class="country-content">
      <div class="country-title">
        {#if selectedCountry === null}
          <h1>Please choose a country</h1>
        {:else}
        <h1>{selectedCountry.name}</h1>
        {/if}
        {#if !isOpen}
        <div>
          <Button on:click={toggle} color="success">
            <span>Manage your D&D content</span>
          </Button>
        </div>
        {/if}
      </div>
      <div class="country-details">
        {#if selectedCountry !== null}
        <p>{selectedCountry.description}</p>
        {/if}
      </div>
    </div>
      <div class="dnd-content-manager {isOpen ? 'open' : ''}" id="dndContentManager">
        <div class="dnd-content-button">
          {#if isOpen}
            <Button on:click={toggle} color="danger">Close your D&D content</Button>
          {/if}
        </div>
        <div class="dnd-content-filtering">
          {#if isOpen}
          <Dropdown>
            <DropdownToggle color="success" caret>Sort monsters</DropdownToggle>
            <DropdownMenu>
              <DropdownItem>Name: A -> Z</DropdownItem>
              <DropdownItem>Name: Z -> A</DropdownItem>
              <DropdownItem>CR: 0 -> 20</DropdownItem>
              <DropdownItem>Name: 20 -> 0</DropdownItem>
            </DropdownMenu>
          </Dropdown>
          <Dropdown>
            <Button color="success" on:click={toggleFilterModal}>
              Show filters
            </Button>
          </Dropdown>
          {/if}
        </div>
        <div class="dnd-content-list">
          <ListGroup>
            {#each monsters as monster (monster.index)}
            <ListGroupItem>
              <div class="d-flex align-items-center justify-content-between">
                <div class="monster-name">
                    {monster.name}
                </div>
                {#if selectedCountry !== null}
                  <Button size="sm">Add</Button>
                {/if}
              </div>
              </ListGroupItem>
            {/each}
          </ListGroup>
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

<Modal isOpen={filterModalOpen} toggle={toggleFilterModal}>
  <ModalHeader toggle={toggleFilterModal}>Filter monsters</ModalHeader>
  <ModalBody>
    <Label for="monsterName">Monster Name</Label>
    <Input type="text" id="monsterName" bind:value={monsterName} placeholder="Enter monster name" />
    <Label for="CR">Challange Rating</Label>
    <Input type="number" id="CR" bind:value={CR} min={0} max={30} placeholder="Enter a CR number" />
    <Label>If a CR is chosen, the monster name will be overruled</Label>
    <Button color="success" on:click={applyFilters}>Apply filters</Button>
  </ModalBody>
</Modal>