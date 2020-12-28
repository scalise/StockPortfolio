<template>
    <v-container fluid>
             <v-row column align-center>        
            <v-col cols="9">
                <h1>Positions {{ positions.length }}</h1>
            </v-col>
            <v-col cols="3">
                <AddPosition @positionInfo="addNewPositionData($event)"></AddPosition>
            </v-col>
        </v-row>
        <v-row>
            <StockPositions 
                    :items="positions" 
                    v-on:updatedPosition="updatedPosition($event)" 
                    v-on:deletedPosition="deletedPosition($event)" 
                    v-on:addedPosition="addedPosition($event)" />
        </v-row>
</v-container>
</template>

<script lang="ts">
    import { Component, Vue } from 'vue-property-decorator';
    import StockPositions from '@/components/StockPositions.vue'; // @ is an alias to /src    
    import AddPosition from '@/components/AddPosition.vue'; // @ is an alias to /src    
       

    @Component({
        components: {
            StockPositions, 
            AddPosition
        },
    })
    export default class Positions extends Vue {

        public positions: Object[] = [];

        async mounted() {
            console.log("mounted");
            if (this.$store.getters['positions/positionCount'] == 0) {
                this.fetchData();                
            }
            this.positions = this.$store.getters['positions/getAll'];
        }

        public fetchData(): void {
            this.$store.dispatch("positions/loadStockPositions");
        }

        public addNewPositionData(value: Object): void {
            console.log(value);

            this.$store.dispatch("positions/addPosition", value);

            //TODO: Call action for new position creation and then use promise to make API call to get latest and refresh.
        }


        public addedPosition(data): void {
            console.log('added position');
        }

        public updatedPosition(data: Position): void {
            console.log('updated position'); 
            this.$store.dispatch("positions/updatePosition", data);
        }

        public deletedPosition(data: Position): void {
            console.log('deleted position');
            this.$store.dispatch("positions/removePosition", data);
        }
    }

</script>
